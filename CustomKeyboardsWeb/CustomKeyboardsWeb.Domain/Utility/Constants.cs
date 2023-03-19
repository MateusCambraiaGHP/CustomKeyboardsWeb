namespace CustomKeyboardsWeb.Domain.Utility
{
    internal class Constants
    {
        public class StatusActive
        {
            public const string Active = "1";
            public const string Inactive = "0";
        }

        public class DefaultValue
        {
            public const int IdNullValue = 0;
            public const int IdMinValue = 1;
        }

        public class ComboboxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public ComboboxItem(string value, string text)
            {
                this.Value = value;
                this.Text = text;
            }
        }

        public class ProductType
        {
            public const string KeyBoard = "1";
            public const string KeyCaps = "2";

            public static string GetDescription(string productName)
            {
                switch (productName)
                {
                    case KeyBoard: return "Teclado";
                    case KeyCaps:  return "Tecla";
                    default:       return "";
                }
            }

            public static List<ComboboxItem> GetComboboxList()
            {
                return new List<ComboboxItem>
                {
                    new ComboboxItem(KeyBoard     , GetDescription(KeyBoard)),
                    new ComboboxItem(KeyCaps      , GetDescription(KeyCaps)),
                };
            }
        }
    }
}
