using apiToDo.DTO;
using System.Collections.Generic;

namespace apiToDo.Services.Interfaces
{
    public interface ITarefaService
    {
        List<TarefaDTO> ListAllTarefas();
        TarefaDTO GetTarefa(int id);
        TarefaDTO InserirTarefa(TarefaDTO tarefa);
        List<TarefaDTO> DeletarTarefa(int id);
    }
}
