using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoClaims
{
    public class ClaimRepo
    {
        private Queue<Claim> _repo = new Queue<Claim>();

        public bool AddClaim(Claim claim)
        {
            int startingCount = _repo.Count;
            _repo.Enqueue(claim);

            bool wasAdded = (_repo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Queue<Claim> GetAllClaims()
        {
            return _repo;
        }
        public Claim PeekClaim()
        {
            if (_repo.Peek() != null)
            {
                return _repo.Peek();
            }
            return null;
        }

        public bool DequeueClaim()
        {
            int startingCount = _repo.Count;
            _repo.Dequeue();

            bool wasDequeued = (_repo.Count < startingCount) ? true : false;
            return wasDequeued;
        }

    }
}
