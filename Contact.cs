using System;
namespace GestionBourget
{
	public class Contact
	{
		private string name;
		private string phone;

        public string Name{
            get { return name; }
            set { name = value; }
        }

        public string Phone{
            get { return phone; }
            set { phone = value; }
        }

        public Contact()
		{
		}

        public Contact(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
    }
}

