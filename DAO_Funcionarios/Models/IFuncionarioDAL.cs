using System.Collections.Generic;

namespace DAO_Funcionarios.Models
{
    public interface IFuncionarioDAL
    {
        IEnumerable<Funcionario> GetAllFuncionarios();
        void AddFuncionario(Funcionario funcionario);
        void UpdateFuncionario(Funcionario funcionario);
        Funcionario GetFuncionario(int? id);
        void DeleteFuncionario(int? id);
    }
}
