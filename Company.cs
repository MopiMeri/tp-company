using System;
namespace GestionBourget
{
	public class Company
	{
		private string siret;
		private string name;
		private Emplacement emplacement;
		private List<Contact> contacts;

        public string Siret
        {
            get { return siret; }
            set { siret = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Emplacement Emplacement
        {
            get { return emplacement; }
            set { emplacement = value; }
        }

        public List<Contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

        public Company()
		{
		}

        public Company(string siret, string name, Emplacement emplacement)
        {
            this.siret = siret;
            this.name = name;
			this.emplacement = emplacement;
			this.contacts = new List<Contact>();
        }
    }
}

