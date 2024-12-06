using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaintMichel
{
    public class OffrePro_API
    {
        private readonly string _baseUrl;

        public OffrePro_API()
        {
            _baseUrl = "http://saintmichel.alwaysdata.net/";
        }

        public async Task<List<OffrePro>> GetOffreProAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Construire l'URL pour la requête GET
                    string url = $"{_baseUrl}/GetAllOffrePro";

                    // Effectuer la requête GET
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Lire le contenu de la réponse
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Désérialiser la réponse JSON en une liste d'objets OffrePro
                    List<OffrePro> offreProList = JsonConvert.DeserializeObject<List<OffrePro>>(jsonResponse);

                    return offreProList;
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs, par exemple journaliser l'exception
                    Console.WriteLine($"Erreur lors de la récupération des offres : {ex.Message}");
                    return null;
                }
            }
        }

        //public async Task<List<OffrePro>> GetOffresAsync()
        //{
        //    Simuler la récupération de données depuis une API ou une source externe
        //    await Task.Delay(1000); // Simuler un délai pour la requête

        //    return new List<OffrePro>
        //    {
        //        new OffrePro { DateStart = "01/01/2024", DateEnd = "01/12/2024", NameEntreprise = "Entreprise A", NameVille = "Paris", Tache = "Développement", TypeOffre = "CDI", SecteurActivite = "Informatique" },
        //        new OffrePro { DateStart = "01/02/2024", DateEnd = "01/08/2024", NameEntreprise = "Entreprise B", NameVille = "Lyon", Tache = "Design", TypeOffre = "CDD", SecteurActivite = "Design" },
        //        new OffrePro { DateStart = "01/03/2024", DateEnd = "01/09/2024", NameEntreprise = "Entreprise C", NameVille = "Marseille", Tache = "Marketing", TypeOffre = "Stage", SecteurActivite = "Marketing" }
        //    };
        //}
    }
}
