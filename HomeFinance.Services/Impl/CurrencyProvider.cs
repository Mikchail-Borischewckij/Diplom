using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;

namespace HomeFinance.Services.Impl
{
    internal class CurrencyProvider : ICurrencyProvider
    {
        private const string Address = "http://www.nbrb.by/Services/XmlExRates.aspx?ondate={0}";
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public CurrencyProvider(LazyInject<IUnitOfWork> lazyUnitOfWork)
        {
            _lazyUnitOfWork = lazyUnitOfWork;
        }

        public IEnumerable<Currency> GetCurrenciesValues(DateTime dateTime)
        {
            string response = GetResponseFromSite(dateTime);
            IDictionary<string, double> result = ParseValues(response);

            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                List<Currency> currencies = unitOfWork.Currencys.Select(EntitiesConverter.ToContract).ToList();
                for (int i = 0; i < currencies.Count; i++)
                {
                    currencies[i].Value = result.FirstOrDefault(pair => currencies[i].Name.Equals(pair.Key, StringComparison.InvariantCultureIgnoreCase)).Value;
                }
                return currencies;
            }
        }

        private IDictionary<string, double> ParseValues(string xml)
        {
            IDictionary<string, double> result = new Dictionary<string, double>();
            XElement xDoc = XElement.Parse(xml);
            IEnumerable<XElement> items = xDoc.Descendants("Currency");
            foreach (XElement item in items)
            {
                XElement element = item.Element("CharCode");
                if (element == null)
                {
                    continue;
                }

                string code = element.Value;
                double value = 0;
                XElement xElement = item.Element("Rate");
                if (xElement != null)
                {
                    value = Convert.ToDouble(xElement.Value.Replace('.', ','));
                }
                result.Add(code, value);
            }
            return result;
        }

        private string GetResponseFromSite(DateTime dateTime)
        {
            WebRequest request = WebRequest.Create(string.Format(Address, dateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            using (StreamReader readStream = new StreamReader(stream))
            {
                return readStream.ReadToEnd();
            }
        }
    }
}
