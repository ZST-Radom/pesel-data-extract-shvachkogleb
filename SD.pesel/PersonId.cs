using System.Collections.Specialized;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SD.pesel;

public class PersonId
{
    private readonly string _id;

    public PersonId(string Id)
    {
        _id = Id;
    }
    /// <summary>
    /// Get full year from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetYear()
    {
        string id = _id; 
        int yearPart = int.Parse(id.Substring(0, 2));


        int monthPart = int.Parse(id.Substring(2, 2));
        if (monthPart  >= 1 && monthPart <= 12)
        {
            int a;
            a = 1900 + yearPart;
            return 1900 + yearPart;
        }
        else if (monthPart >= 21 && monthPart <= 32)
        {
            int b;
            b = 2000 + yearPart;
            return 2000 + yearPart;
        }
        else {
            return -1;
        }
    }

    /// <summary>
    /// Get month from PESEL
    /// </summary>
    public int GetMonth()
    {
        string id = _id;
        int monthPart = int.Parse(id.Substring(2, 2));


        if (monthPart >= 1 && monthPart <= 12)
        {

            return monthPart;
        }
        else if (monthPart >= 21 && monthPart <= 32)
        {

            return monthPart - 20;
        }
        else { 
          return 0; 
        }
    }

    /// <summary>
    /// Get day from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetDay()
    {
        string id = _id;
        int getday = int.Parse(id.Substring(4, 2));
        return getday;
    }

    /// <summary>
    /// Get year of birth from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetYearOfBirth()
    {
        string id = _id;
        int yearPart1 = int.Parse(id.Substring(0, 2));


        int monthPart1 = int.Parse(id.Substring(2, 2));
        if (monthPart1 >= 1 && monthPart1 <= 12)
        {
            int a;
            a = 1900 + yearPart1;
            return 2024 - a;
        }
        else if (monthPart1 >= 21 && monthPart1 <= 32)
        {
            int b;
            b = 2000 + yearPart1;
            return 2024 - b;

        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// Get gender from PESEL
    /// </summary>
    /// <returns>m</returns>
    /// <returns>f</returns>
    public string GetGender()
    {
        string id = _id;
        int genderDigit = int.Parse(id.Substring(9, 1));

        if (genderDigit % 2 == 0)
        {
            return "k";
        }
        else
        {
            return "m";
        }
    }

    /// <summary>
    /// check if PESEL is valid
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        string id = _id;
        int sum = 0;
        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        if (id.Length != 11) { 
           return false;
        }
        for (int i = 0; i < 10; i++)
        {
            sum += Convert.ToInt32(id[i]) * weights[i];
        }
        if (sum >= 10 && sum <= 99 || sum <= -10 && sum >= -99)
        {
            string a = sum.ToString();
            a = a.Substring(0, 1);
            int b = Convert.ToInt32(a);
            int c = 10 - b;
            char c3 = Convert.ToChar(c);
            if (c3 == id[10])
            {
                return true;
            }
            else { return false; }
        }
        else {
            int b2 = Convert.ToInt32(sum);
            int c1 = 10 - b2;
            char c2 = Convert.ToChar(c1);
            if (c2 == id[10]) { return true; }
            else { return false; }
        }
    }
}