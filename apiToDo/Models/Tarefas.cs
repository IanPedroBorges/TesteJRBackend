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
        

        public List<TarefaDTO> listAllTarefas()
        {
            return lstTarefas.ToList();
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
