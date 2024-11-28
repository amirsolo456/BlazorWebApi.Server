using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities.Shared;
using BlazorWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BlazorWebApi.InfraStructure.Repository
{
    public class CommentsService : ICommentsService
    {
        private ApplicationDbContext _Context;
        public CommentsService(ApplicationDbContext Context)
        {
                _Context = Context;
        }
        public IEnumerable<Comments> getComentsForVillaByScore(int Score, int VillaID)
        {
            return _Context.tblComment.Where(c => c.Score == Score && c.VillaID == VillaID).OrderByDescending(c => c.CreatedAt);
        }

        public IEnumerable<Comments> getCommentsForVilla(int VillaID)
        {
            return _Context.tblComment.Where(c =>  c.VillaID == VillaID).OrderByDescending(c => c.CreatedAt);
        }
    }
}
