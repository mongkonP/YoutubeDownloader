

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using System.Reflection;
namespace TORServices.Systems
{

    
    public static class extType
    {
       /* public static IEnumerable<Control> GetAllControl(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControl(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);

            List<Control> c = Controls.OfType<TextBox>().Cast<Control>().ToList();

        }*/
       public static IEnumerable<T> GetControlsOfType<T>( Control root)
      where T : Control
        {
            var t = root as T;
            if (t != null)
                yield return t;

            var container = root as ContainerControl;
            if (container != null)
                foreach (Control c in container.Controls)
                    foreach (var i in GetControlsOfType<T>(c))
                        yield return i;
        }
       public static List<BindingSource> GetBindingSourceinFrom(this IContainer f)
       {
          // List<BindingSource> lst = new List<BindingSource>();

        return  (from Component bs in f.Components
            where bs is BindingSource
            select bs as BindingSource).ToList();/*.ForEach(b =>
            {
                BindingSource bds = b as BindingSource;
                lst.Add(bds);
            });*/

          // return lst;
           
       }
      /* private IEnumerable<Component> EnumerateComponents()
       {
           return from field in GetType().GetFields(
                       BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                  where typeof(Component).IsAssignableFrom(field.FieldType)
                  let component = (Component)field.GetValue(this)
                  where component != null
                  where component.GetType().GetProperty("Name") == null
                  select component;
       }
       
         (from Component bs in this.components.Components
                where bs is BindingSource
                select bs).ToList().ForEach(b =>
               {
                   BindingSource bds = b as BindingSource;

                   MessageBox.Show(bds.Count.ToString());
               });
        */
       public static string BinaryToString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                throw new ArgumentNullException("binary");

            if ((binary.Length % 8) != 0)
                throw new ArgumentException("Binary string invalid (must divide by 8)", "binary");

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            for (int i = 0; i < binary.Length; i += 8)
            {
                string section = binary.Substring(i, 8);
                int ascii = 0;
                try
                {
                    ascii = Convert.ToInt32(section, 2);
                }
                catch
                {
                    throw new ArgumentException("Binary string contains invalid section: " + section, "binary");
                }
                builder.Append((char)ascii);
            }
            return builder.ToString();
        }


        public static Boolean IsNumber(this object Value)
        {
            Boolean b = false;
            int i;

            try
            {
                i = int.Parse(Value.ToString());
            }
            catch { b = false; }
            return b;
        }
        public static bool IsIP(this string input)
        {
            try
            {
                System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"(^\d{1,}\.\d{1,}\.\d{1,}\.\d{1,}\z)");
                if (input.Length > 0)
                {
                    return rex.IsMatch(input);
                }
                else
                {
                    throw new Exception("Email length is must be more then zero");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Boolean IsEmail(this string input)
        {
            try
            {
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (input.Length > 0)
                {
                    return reg.IsMatch(input);
                }
                else
                {
                    throw new Exception("Email length is must be more then zero");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DateTime ToDateTime(this string strDate, string Date_Format = "yyyyMMdd hhmmss", string Era_Type = "en-US")
        {
            DateTime date1;
            try
            {
                System.DateTime.TryParseExact(strDate, Date_Format, new System.Globalization.CultureInfo(Era_Type), System.Globalization.DateTimeStyles.None, out date1);
                return date1;
            }
            catch { }
            {
               // throw (new ApplicationException(System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message));
                return DateTime.MinValue;
                
            }
        }
      /*  public static DateTime ToDateTime(this string strDate, string Date_Format ="yyyyMMdd hhmmss", string Era_Type = "en-US")
       {
           DateTime dRet;
           return (DateTime.TryParseExact(strDate, Date_Format,
                                       new System.Globalization.CultureInfo("en-US"),
                                       System.Globalization.DateTimeStyles.None,
                                       out dRet)) ? dRet : DateTime.Parse(strDate);

       }*/

        public static DateTime CultureDateTime(this DateTime dt, string DateFormat = "dd-MM-yyyy")
        {

            return CultureDateTime(dt, new System.Globalization.CultureInfo("th-TH"), DateFormat);
        }
        public static DateTime CultureDateTime(this DateTime dt, string  _CultureInfo, string DateFormat = "dd-MM-yyyy")
        {
            return CultureDateTime(dt, new System.Globalization.CultureInfo(_CultureInfo), DateFormat);
        }

        public static DateTime CultureDateTime(this DateTime dt, System.Globalization.CultureInfo _CultureInfo, string DateFormat = "dd-MM-yyyy")
        {
            return DateTime.Parse(dt.ToString(DateFormat, _CultureInfo));
        }

       public static double ToDouble(this object input, int deci = 2)
       {
           double d;
           try
           {
               d = Convert.ToDouble(input.ToString());
               d = Convert.ToDouble(d.ToString("N" + deci)); 
               
           }
           catch { d = 0; }
           return d;
       }
        public static double NextDouble(this Random r, double min, double max, int digit = 3)
        {
            System.Threading.Thread.Sleep(1000);
            return Convert.ToDouble((new Random().NextDouble() * (max - min) + min).ToString("N" + digit));
        }
        public static int ToInt(this object input)
       {
           int d;
           try
           {
               d = Convert.ToInt32(input.ToDouble());
           }
           catch { d = 0; }
           return d;
       }

        public static string TimeToString(this TimeSpan time)
        {
            string st = "00";

            if (time.TotalSeconds > 0)
                st = time.TotalSeconds.ToString("00");

            if (time.TotalMinutes > 0)
                st = time.TotalMinutes.ToString("00")+ ":" + st;

            if (time.TotalHours > 0)
                st = time.TotalHours.ToString("00") + ":" + st;
            return st;
        
        }
    }

   

   
   
    

}
