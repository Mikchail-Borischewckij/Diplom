﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Services;

namespace HomeFinance.Host1
{
	public class AccountNotificatorService : IAccountNotificatorService
	{
		private readonly IAccountsService _accountsService;
		private readonly IIncomeService _incomeService;
		private readonly ICostsService _costsService;
		private static Timer _timer;

		public AccountNotificatorService(IAccountsService accountsService,IIncomeService incomeService,ICostsService costsService)
		{
			_accountsService = accountsService;
			_incomeService = incomeService;
			_costsService = costsService;
			_timer = new Timer(10000);

			_timer.Elapsed += OnTimedEvent;
			_timer.AutoReset = true;
			_timer.Enabled = true;
		}

		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			UpdateAccounts();
		}

		private IResult<bool> UpdateAccounts()
		{
			try
			{
				var accounts = _accountsService.ReadAll();
				foreach (var item in accounts)
				{
					UpdateIncomes(item.Incomes);
					UpdateCosts(item.Сonsumptions);
				}
				return new Result<bool>(true);
			}
			catch (Exception ex)
			{
				return new Result<bool>(false);
			}
		}

		private void UpdateIncomes(IEnumerable<Income> incomes)
		{
			foreach (Income income in incomes.Where(x => x.TransactionType == TransactionType.Mountly))
			{
				if (!income.UpdatedDate.HasValue)
				{
					continue;
				}

				Income copy = income;
				DateTime date = income.UpdatedDate.Value;
				DateTime currentDate = DateTime.Now;
				if (date.Year != currentDate.Year || date.Month != currentDate.Month || date.Day != currentDate.Day)
				{
					continue;
				}
				Income newIncome = new Income(copy.Id, copy.Amount, copy.Description, currentDate, null, TransactionType.Single, copy.AccountId,
					copy.CategoryId);
				IResult<Income> result = _incomeService.Create(newIncome);

				if (result.IsSuccess)
				{
					income.UpdatedDate = income.UpdatedDate.Value.AddDays(30);
					_incomeService.Update(income);
				}
			}
		}

		private void UpdateCosts(IEnumerable<Cost> costs)
		{
			foreach (Cost cost in costs.Where(x => x.TransactionType == TransactionType.Mountly))
			{
				if (!cost.UpdatedDate.HasValue)
				{
					continue;
				}

				Cost copy = cost;
				DateTime date = cost.UpdatedDate.Value;
				DateTime currentDate = DateTime.Now;
				if (date.Year != currentDate.Year || date.Month != currentDate.Month || date.Day != currentDate.Day)
				{
					continue;
				}
				Cost newIncome = new Cost(copy.Id, copy.Amount, copy.Description, currentDate, null, TransactionType.Single, copy.AccountId,
					copy.CategoryId);
				IResult<Cost> result = _costsService.Create(newIncome);
				if (result.IsSuccess)
				{
					cost.UpdatedDate = cost.UpdatedDate.Value.AddDays(30);
					_costsService.Update(cost);
				}
			}
		}

		public void StartUpdateAccounts()
		{
			_timer.Start();
		}

		public void StopUpdateAccounts()
		{
			_timer.Stop();
		}
	}
}