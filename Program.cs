using GestionBourget;
using System;
using System.Collections.Generic;
using System.Diagnostics;
internal class Program
{
    
    private static void Main(string[] args)
    {
        List<Emplacement> emplacements = new List<Emplacement>();
        List<Company> companies = new List<Company>();

         void displayMenu()
         {
            Console.WriteLine("################");
            Console.WriteLine("#GestionBourget#");
            Console.WriteLine("################");
            Console.WriteLine("1 - Saisir un emplacement");
            Console.WriteLine("2 - Saisir une entreprise");
            Console.WriteLine("3 - Saisir un contact");
            Console.WriteLine("4 - Afficher les exposants");
            Console.WriteLine("0 - Quitter l'application");

        }

        Emplacement create_em(){
            Console.Clear();
            Console.WriteLine("Saisissez le hall. (de A à Z)");
            string hall = Console.ReadLine();
            Console.WriteLine("Saisissez la parcelle. (>1)");
            int parcelle = int.Parse(Console.ReadLine());
            Console.WriteLine("Saisissez la surface. (>1)");
            int surface = int.Parse(Console.ReadLine());
            Emplacement emp = new Emplacement(hall, parcelle, surface);
            emplacements.Add(emp);
            return emp;
        }

        Company create_co(List<Emplacement> emplacements)
        {
            Console.Clear();
            int choix = 0;
            Console.WriteLine("Sélectionnez un emplacement pour y placer votre entreprise :");
            foreach (var emplacement in emplacements)
            {
                
                Console.WriteLine($"{choix}. Hall : {emplacement.Hall}, Parcelle : {emplacement.Parcelle}, Surface : {emplacement.Surface}m²");
                choix = choix + 1;
            }

            int choixEmplacement= int.Parse(Console.ReadLine()) ;
            if (choixEmplacement < 0 || choixEmplacement >= emplacements.Count)
            {
                Console.WriteLine("Choix d'emplacement invalide.");
                return null;
            }

            Company new_comp = new Company();
            new_comp.Emplacement = emplacements[choixEmplacement];
            Console.WriteLine("Saisissez un numéro de SIRET.");
            new_comp.Siret = Console.ReadLine();
            Console.WriteLine("Saisissez le nom de l'entreprise.");
            new_comp.Name = Console.ReadLine();
            companies.Add(new_comp);
            return new_comp;
        }


        Company add_cont(List<Company> companies, Company a)
        {
            a.Contacts = new List<Contact>();

            Console.WriteLine("Combien de contacts voulez-vous ajouter ?");
            int nbr_cont = int.Parse(Console.ReadLine());

            for (int i = 0; i < nbr_cont; i++)
            {
                Contact new_cont = new Contact();
                Console.WriteLine("Saisissez le nom du contact "+(i+1)+" :");
                new_cont.Name = Console.ReadLine();
                Console.WriteLine("Saisissez le numéro du contact "+(i+1)+" :");
                new_cont.Phone = Console.ReadLine();
                a.Contacts.Add(new_cont);
            }
            return a;
        }

        void display_comp(){
            for (int i = 0; i < companies.Count; i++)
            {
                Console.WriteLine((i + 1) + "." + companies[i].Name);
                Console.WriteLine("Hall : " + companies[i].Emplacement.Hall);
                Console.WriteLine("Parcelle : " + companies[i].Emplacement.Parcelle);
                Console.WriteLine("Surface : " + companies[i].Emplacement.Surface + "m²");
            }
        }
        void display_cont(){
            for (int i = 0; i < companies.Count; i++)
            {
                Console.WriteLine((i + 1) + "." + companies[i].Name);
                for (int j = 0; j < companies[i].Contacts.Count; j++){
                    Console.WriteLine(companies[i].Contacts[j].Name);
                }
            }
        }

        bool menuOn = true;

        while (menuOn)
        {
            displayMenu();
            int userEntry = int.Parse(Console.ReadLine());
            Emplacement b_emp = new Emplacement();
            Company b_comp = new Company();
            switch (userEntry)
            {
                case 1:
                    b_emp = create_em();
                    break;

                case 2:
                    if (emplacements.Count == 0){
                        Console.WriteLine("Il est nécessaire de créer un emplacement avant d'y assigner une entreprise.");
                        break;
                    }
                    else{
                        b_comp = create_co(emplacements);
                        break;
                    }
                case 3:
                    if (companies.Count == 0){
                        Console.WriteLine("Il est nécessaire de créer une entreprise avant d'y assigner un contact.");
                        break;
                    }
                    else{
                        Console.WriteLine("Sélectionnez une entreprise pour ajouter des contacts :");
                        for (int i = 0; i < companies.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {companies[i].Name}");
                        }

                        int choixEntreprise = int.Parse(Console.ReadLine()) - 1;
                        if (choixEntreprise < 0 || choixEntreprise >= companies.Count)
                        {
                            Console.WriteLine("Choix d'entreprise invalide.");
                            break;
                        }
                        companies[choixEntreprise] = add_cont(companies, companies[choixEntreprise]);
                        break;
                    }
                case 4:
                    Console.WriteLine("Liste des entreprises ainsi que leur emplacement :");
                    display_comp();
                    Console.WriteLine("\nListe des contacts par entreprise :");
                    display_cont();
                    break;
                case 0:
                    menuOn = false;
                    break;
            }
        }

    }
}