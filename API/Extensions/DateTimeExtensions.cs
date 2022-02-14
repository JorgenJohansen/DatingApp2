namespace Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            //If they have not had their birthday yet
            if(dob.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}