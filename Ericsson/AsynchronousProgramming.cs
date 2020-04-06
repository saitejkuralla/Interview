using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    class AsynchronousProgramming
    {
        public void DoOperation()
        {
            AsynchronousOperation oAsynchronousOperation = new AsynchronousOperation();
            oAsynchronousOperation.CompleteTheOperation();
        }
        
    }

    public class AsynchronousOperation
    {
        public void CompleteTheOperation()
        {
            Task<int> totalTask = GetResult();
            Console.Write(totalTask.Result);
        }

        private async Task<int> GetResult()
        {
            Task<int> aTask = GetResultFromA();
            Task<int> bTask = GetResultFromB();
            int[] resultArrays = await Task.WhenAll(aTask, bTask);
            return resultArrays.Sum();
        }

        private Task<int> GetResultFromA()
        {
            return Task.FromResult(10);
        }
        private Task<int> GetResultFromB()
        {
            return Task.FromResult(5);
        }
    }

    public class AsynchronousUserOperation
    {

        public void DoAsynchronousUserOperationAsync()
        {
            var repo = new Repository();
            var userIds = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Task<IEnumerable<User>> users = repo.GetUsers(userIds);
            foreach (var user in users.Result)
            {
                Console.WriteLine(user.Name);
            }
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Repository
        {            
            public Task<User> GetUser(int id)
            {
                return Task.FromResult(new User { Id = id, Name = "Name " + id });
            }

            public async Task<IEnumerable<User>> GetUsers(List<int> ids)
            {                
                List<Task<User>> users = new List<Task<User>>();
                
                foreach (var id in ids)                
                    users.Add(GetUser(id));                

                User[] resultUsers = await Task.WhenAll(users);
                return resultUsers;
            }


        }
    }
}
