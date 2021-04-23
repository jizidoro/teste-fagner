#region

using System.Collections;
using System.Collections.Generic;
using kpmg.Application.Dtos;

#endregion

namespace kpmg.UnitTests.Tests.AutenticacaoTests.TestDatas
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
                    Chave = "1",
                    Senha = "123456"
                }
            };
            yield return new object[]
            {
                200, new AutenticacaoDto
                {
                    Chave = "2",
                    Senha = "123456"
                }
            };
            yield return new object[]
            {
                200, new AutenticacaoDto
                {
                    Chave = "3",
                    Senha = "123456"
                }
            };
            yield return new object[]
            {
                1001, new AutenticacaoDto
                {
                    Chave = "4",
                    Senha = "1234567"
                }
            };
        }

        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}