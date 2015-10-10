﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Models.Field.Dtos;

namespace WebApp.Controllers_API
{
    public class ProvidersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Providers
        public IQueryable<ProviderUser> GetUsers()
        {
            return db.Users.OfType<ProviderUser>();
        }

        // GET: api/Providers/5
        [ResponseType(typeof(ProviderDataDto))]
        public IHttpActionResult GetProviderUser(int id)
        {
            ProviderUser providerUser = db.Users.FirstOrDefault(u => u.Id == id) as ProviderUser;
            if (providerUser == null)
            {
                return NotFound();
            }

            return Ok(new ProviderDataDto(providerUser));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProviderUserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}