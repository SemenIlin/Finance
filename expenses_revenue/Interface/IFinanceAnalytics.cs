namespace expenses_revenue.Interface
{
    interface IFinanceAnalytics
    {
        void AddIncome();
        void AddExpense();
        void GetTableOfIncomes();
        void GetTableOfExpenses();
        void GetTableOfAnalysis();
    }
}
