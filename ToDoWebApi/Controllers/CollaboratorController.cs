using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToDoWebApi.Models;

namespace ToDoWebApi.Controllers
{
    
    public class CollaboratorController : ApiController
    {
        private TodoContext db = new TodoContext();

        // GET: api/Collaborator
        public IQueryable<Collaborator> GetCollaborators()
        {
            return db.Collaborators;
        }

        // GET: api/Collaborator/5
        [ResponseType(typeof(Collaborator))]
        public IHttpActionResult GetCollaborator(int id)
        {
            Collaborator collaborator = db.Collaborators.Find(id);
            if (collaborator == null)
            {
                return NotFound();
            }

            return Ok(collaborator);
        }

        // PUT: api/Collaborator/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCollaborator(int id, Collaborator collaborator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != collaborator.CollaboratorID)
            {
                return BadRequest();
            }

            db.Entry(collaborator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollaboratorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Collaborator
        [ResponseType(typeof(Collaborator))]
        public IHttpActionResult PostCollaborator(Collaborator collaborator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Collaborators.Add(collaborator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = collaborator.CollaboratorID }, collaborator);
        }

        // DELETE: api/Collaborator/5
        [ResponseType(typeof(Collaborator))]
        public IHttpActionResult DeleteCollaborator(int id)
        {
            Collaborator collaborator = db.Collaborators.Find(id);
            if (collaborator == null)
            {
                return NotFound();
            }

            db.Collaborators.Remove(collaborator);
            db.SaveChanges();

            return Ok(collaborator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CollaboratorExists(int id)
        {
            return db.Collaborators.Count(e => e.CollaboratorID == id) > 0;
        }
    }
}