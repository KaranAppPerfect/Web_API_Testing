using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMinimalApi.Tests
{
    public class TestPeopleService : IPeopleService
    {
        public string Create(Person person) => "It works!";
    }
}
