using Interchange.Data;
using Interchange.Entity;
using System;
using System.Collections.Generic;

namespace Interchange.WCF
{
    public class HubInternal : IHubInternal
    {
        private IDbInternal repository;

        public HubInternal(IDbInternal repo)
        {
            repository = repo;
        }

        public string DeleteTransaction(string id)
        {
            return repository.DeleteRecord(int.Parse(id));
        }

        public TransactionPayment GetPayment(string id)
        {
            return repository.GetPayment(int.Parse(id));
        }

        public string PostAddress(IXAddress address, string id)
        {
            try
            {
                repository.InsertAddress(address, int.Parse(id));
                return ResponseType.Success.ToString();
            }
            catch (Exception ex)
            {
                ex.HelpLink = "";
                throw ex;
            }
        }

        public string PostDetail(IXDetail detail, string id)
        {
            try
            {
                repository.InsertDetail(detail, int.Parse(id));
                return ResponseType.Success.ToString();
            }
            catch (Exception ex)
            {
                ex.HelpLink = "";
                throw ex;
            }
        }

        public string PostDetails(IEnumerable<IXDetail> details, string id)
        {
            try
            {
                int interchId = int.Parse(id);
                foreach (IXDetail detail in details)
                {
                    repository.InsertDetail(detail, interchId);
                }
                return ResponseType.Success.ToString();
            }
            catch (Exception ex)
            {
                ex.HelpLink = "";
                throw ex;
            }
        }

        public string PostHeader(IXHeader header)
        {
            try
            {
                return repository.InsertTransaction(header).ToString();
            }
            catch (Exception ex)
            {
                ex.HelpLink = "";
                throw ex;
            }
        }

        public string PostName(IXName name, string id)
        {
            try
            {
                repository.InsertName(name, int.Parse(id));
                return ResponseType.Success.ToString();
            }
            catch (Exception ex)
            {
                ex.HelpLink = "";
                throw ex;
            }
        }
    }
}