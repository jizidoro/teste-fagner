#region

using System.Collections;
using System.Collections.Generic;
using kpmg.Application.Dtos;

#endregion

namespace kpmg.UnitTests.Tests.BaUsuTests.TestDatas
{
    internal class AutenticacaoDtoTestData : IEnumerable<object[]>
    {
        #region TestData

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                200, new AutenticacaoDto
                {
                    Chave = "20203",
                    Senha = "12345"
                },
                1001, new AutenticacaoDto
                {
                    Chave = "2020",
                    Senha = "12345"
                },
                1001, new AutenticacaoDto
                {
                    Chave = "20203",
                    Senha = "1234"
                },
                1001, new AutenticacaoDto
                {
                   
                },
                1001, new AutenticacaoDto
                {
                    Chave = "21271",
                    Senha = "241039"
                },
            };
        }

        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}