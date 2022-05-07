using System;

namespace TrackingService.Model
{

    public static class StatusCode
    {
        public static string INCOME_FILE_NAME = Environment.CurrentDirectory + "\\pftStore\\income.xml";
        public static string EXPENSE_FILE_NAME = Environment.CurrentDirectory + "\\pftStore\\expense.xml";
        public static string CATEGORY_FILE_NAME = Environment.CurrentDirectory + "\\pftStore\\category.xml";
        public static string USER_STORE = Environment.CurrentDirectory + "\\pftStore\\register.xml";

        public static string INCOME = "Income";
        public static string EXPENSE = "Expense";

        public static int SUCCESS = 200;
        public static string myConnectionString = "server=localhost;uid=root;pwd=admin;database=tracker_service";

    }
}