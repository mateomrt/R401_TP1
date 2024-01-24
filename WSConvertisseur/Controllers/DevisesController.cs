using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        private List<Devise> devises;

        public DevisesController()
        {

            devises = new List<Devise>
            {
                new Devise { Id = 1, NomDevise = "Dollar", Taux = 1.08 },
                new Devise { Id = 2, NomDevise = "Franc Suisse", Taux = 1.07 },
                new Devise { Id = 3, NomDevise = "Yen", Taux = 120 },
            };
        }

        /// <summary>
        /// Récupère toutes les devises.
        /// </summary>
        /// <returns>Une collection de devises.</returns>
        // GET: api/<DevisesController>
        [ProducesResponseType(200)]
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return devises;
        }

        /// <summary>
        /// Récupère une devise par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la devise à récupérer.</param>
        /// <returns>La devise correspondante.</returns>
        /// <response code="404">L'identifiant n'existe pas</response>
        /// <response code="200">Quand la devise est renvoyée</response>
        // GET api/<DevisesController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Devise> GetById(int id)
        {
            Devise? devise = devises.FirstOrDefault((d) => d.Id == id);
            
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }

        /// <summary>
        /// Ajoute une nouvelle devise.
        /// </summary>
        /// <param name="devise">La devise à ajouter.</param>
        /// <returns>La devise ajoutée avec un code de statut 201 (Created).</returns>
        /// <response code="201">Réussite de la création</response>
        // POST api/<DevisesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if(!ModelState.IsValid)
{
                return BadRequest(ModelState);
            }
            devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Met à jour une devise existante.
        /// </summary>
        /// <param name="id">Identifiant de la devise à mettre à jour.</param>
        /// <param name="devise">La devise mise à jour.</param>
        /// <returns>Aucun contenu avec un code de statut 204 (No Content) si la mise à jour est réussie.</returns>
        /// <response code="201">Mise à jour réussi</response>
        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = devises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            devises[index] = devise;
            return NoContent();
        }

        /// <summary>
        /// Supprime une devise par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la devise à supprimer.</param>
        /// <returns>La devise supprimée avec un code de statut 200 (OK).</returns>
        /// <response code="404">L'identifiant n'existe pas</response>
        /// <response code="200">La devise est supprimée</response>
        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Devise> Delete(int id)
        {
            Devise? devise = devises.FirstOrDefault((d) => d.Id == id);

            if (devise == null)
            {
                return NotFound();
            }
            devises.Remove(devise);
            return devise;
        }
    }
}
