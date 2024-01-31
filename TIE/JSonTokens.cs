using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TIE
{
    [Serializable]
    internal class JSonTokens
    {
        private List<string> _packageTokens = [];
        private List<string> _documentTokens = [];
        private List<string> _searchTokens = [];

        public List<string> PackageTokens { get => _packageTokens; set => _packageTokens = value; }
        public List<string> DocumentTokens { get => _documentTokens; set => _documentTokens = value; }
        public List<string> SearchTokens { get => _searchTokens; set => _searchTokens = value; }
    }
}
