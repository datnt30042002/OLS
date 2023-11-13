namespace OLS.HelperFunctions
{
    public static class HelperFunctions
    {
        // Current user age
        // <Summary>
        // Sử dụng DateTime khi bạn chỉ quan tâm đến thời gian và ngày mà không cần thông tin về múi giờ.
        // Sử dụng DateTimeOffset khi bạn cần biểu diễn thông tin về múi giờ để đảm bảo tính chính xác khi làm việc với các ứng dụng quốc tế hoặc khi cần xử lý đèn xanh và giờ hạ đặt.
        // <Summary>
        public static int GetCurrentAge(this DateTime dateTime)
        {
            var currentDate = DateTime.Now; // Múi giờ
            int age = currentDate.Year - dateTime.Year;

            if (currentDate < dateTime.AddYears(age))
            {
                age--;
            }

            return age;
        }

        // Show user status
        public static string GetStatusString(int status)
        {
            return status == 1 ? "Active" : "Inactive";
        }

        // Convert string status to int value
        public static string ConvertStatusToValue(string status)
        {
            return status?.ToLower() == "active" ? "1" : status?.ToLower() == "inactive" ? "0" : null;
        }

    }
}
