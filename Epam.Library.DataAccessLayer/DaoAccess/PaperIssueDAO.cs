using System;
using System.Collections.Generic;
using System.Linq;
using DalContracts;
using DataAccessLayer.Repository;
using Entities;

namespace DataAccessLayer.DaoAccess
{
    public class PaperIssueDAO : IPaperIssueDAO
    {
        public int AddItem(PaperIssue paper)
        {
            paper.Id = ++IdStorage.UniqueId;
            PaperIssueRepository.GetPaperIssueRepository().Papers.Add(paper);
            return IdStorage.UniqueId;
        }

        public bool Exists(PaperIssue paper)
        {
            if (!string.IsNullOrEmpty(paper.Paper.Issn))
            {
                var result = from paperEnt in PaperIssueRepository.GetPaperIssueRepository().Papers
                             where paperEnt.Paper.Issn == paper.Paper.Issn
                             select paperEnt;

                return result.Any();
            }
            else
            {
                var result = from paperEnt in PaperIssueRepository.GetPaperIssueRepository().Papers
                             where paperEnt.Paper.Name == paper.Paper.Name
                             where paperEnt.Publisher == paper.Publisher
                             where paperEnt.YearOfPublishing == paper.YearOfPublishing
                             select paperEnt;
                return result.Any();
            }
        }

        public IEnumerable<PaperIssue> GetAllItems()
        {
            return PaperIssueRepository.GetPaperIssueRepository().Papers.ToArray();
        }

        public PaperIssue GetItemById(int id)
        {
            return PaperIssueRepository.GetPaperIssueRepository().Papers.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<PaperIssue> GetPaperIssuesByPaperId(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(int id)
        {
            var result = PaperIssueRepository.GetPaperIssueRepository().Papers.RemoveAll(paper => paper.Id == id);

            return result > 0;
        }

        public bool Update(PaperIssue paper)
        {
            throw new NotImplementedException();
        }
    }
}