using System;

class Camion
{
    public string NumeroPlaque;
    public string Marque;
    public int AnneeFabrication;
}

class ListeCamions
{
    private Camion[] tableau;
    private int nbCamions;

    public ListeCamions(int taille)
    {
        tableau = new Camion[taille];
        nbCamions = 0;
    }

    public void AjouterCamion(Camion camion)
    {
        if (nbCamions < tableau.Length)
        {
            tableau[nbCamions] = camion;
            nbCamions++;
        }
        else
        {
            Console.WriteLine("Erreur: Liste de camions pleine.");
        }
    }

    public bool PlaqueDejaEncodee(string numeroPlaque)
    {
        for (int i = 0; i < nbCamions; i++)
        {
            if (tableau[i].NumeroPlaque == numeroPlaque)
            {
                return true;
            }
        }
        return false;
    }

    public void TrierParNumeroPlaque()
    {
        for (int i = 0; i < nbCamions - 1; i++)
        {
            for (int a = i + 1; a < nbCamions; a++)
            {
                bool echange = false;
                int longueurI = tableau[i].NumeroPlaque.Length;
                int longueurA = tableau[a].NumeroPlaque.Length;
                int b = 0;

                while (b < longueurI && b < longueurA)
                {
                    if (tableau[i].NumeroPlaque[b] > tableau[a].NumeroPlaque[b])
                    {
                        echange = true;
                        b = longueurI + 1;
                    }
                    else if (tableau[i].NumeroPlaque[b] < tableau[a].NumeroPlaque[b])
                    {
                        b = longueurI + 1;
                    }
                    else
                    {
                        b++;
                    }
                }

                if (b == longueurI && b != longueurA)
                {
                    echange = false;
                }
                else if (b != longueurI && b == longueurA)
                {
                    echange = true;
                }

                if (echange)
                {
                    Camion camionTemporaire = tableau[i];
                    tableau[i] = tableau[a];
                    tableau[a] = camionTemporaire;
                }
            }
        }
    }

    public void AfficherCamions()
    {
        for (int i = 0; i < nbCamions; i++)
        {
            Console.WriteLine("Camion " + (i + 1) + " :");
            Console.WriteLine("  Numéro de plaque: " + tableau[i].NumeroPlaque);
            Console.WriteLine("  Marque: " + tableau[i].Marque);
            Console.WriteLine("  Année de fabrication: " + tableau[i].AnneeFabrication);
        }
    }
}

class Programme
{
    public void Executer()
    {
        int nbCamions;
        Console.WriteLine("Nombre de camions à encoder: ");
        while (!int.TryParse(Console.ReadLine(), out nbCamions) || nbCamions <= 0)
        {
            Console.WriteLine("Erreur: Veuillez entrer un nombre valide de camions.");
        }

        ListeCamions listeCamions = new ListeCamions(nbCamions);

        for (int i = 0; i < nbCamions; i++)
        {
            Camion camion = new Camion();

            Console.WriteLine("Numéro de plaque du camion " + (i + 1) + ":");
            string numeroPlaque = Console.ReadLine();

            while (listeCamions.PlaqueDejaEncodee(numeroPlaque))
            {
                Console.WriteLine("Erreur: La plaque d'immatriculation est déjà encodée. Veuillez entrer une nouvelle plaque.");
                numeroPlaque = Console.ReadLine();
            }
            camion.NumeroPlaque = numeroPlaque;

            Console.WriteLine("Marque du camion " + (i + 1) + ":");
            camion.Marque = Console.ReadLine();

            Console.WriteLine("Année de fabrication du camion " + (i + 1) + ":");
            int anneeFabrication;
            while (!int.TryParse(Console.ReadLine(), out anneeFabrication) || anneeFabrication < 0)
            {
                Console.WriteLine("Erreur: Veuillez entrer une année valide.");
            }
            camion.AnneeFabrication = anneeFabrication;

            listeCamions.AjouterCamion(camion);
        }

        listeCamions.TrierParNumeroPlaque();
        Console.WriteLine("Informations des camions:");
        listeCamions.AfficherCamions();
    }

    public static void Main(string[] args)
    {
        new Programme().Executer();
    }
}
