using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        private static readonly List<TarefaDTO> lstTarefas = new List<TarefaDTO>()
        {
            new TarefaDTO
            {
                ID_TAREFA = 1,
                DS_TAREFA = "Fazer Compras"
            },
            new TarefaDTO
            {
                ID_TAREFA = 2,
                DS_TAREFA = "Fazer Atividad Faculdade"
            },
            new TarefaDTO
            {
                ID_TAREFA = 3,
                DS_TAREFA = "Subir Projeto de Teste no GitHub"
            }
        };
        
        // Método para listar todas as tarefas
        public List<TarefaDTO> listAllTarefas()
        {
            // retorna a lista de tarefas
            return lstTarefas.ToList();
        }

        // Metodo para retornar uma tarefa pelo ID

        public TarefaDTO GetTarefa(int ID_TAREFA)
        {
            // busca a tarefa pelo ID
            var tarefa = lstTarefas.FirstOrDefault(t => t.ID_TAREFA == ID_TAREFA);

            // Verifica se a tarefa existe
            if (tarefa == null)
            {
                // Retorna um erro KeyNotFoundException caso a tarefa não exista
                throw new KeyNotFoundException($"Tarefa com ID {ID_TAREFA} não encontrada.");
            }

            // Retorna a tarefa encontrada
            return tarefa;
            
        }


        public void InserirTarefa(TarefaDTO Request)
        {
            return;
        }
        public void DeletarTarefa(int ID_TAREFA)
        {
            return;
        }
    }
}
