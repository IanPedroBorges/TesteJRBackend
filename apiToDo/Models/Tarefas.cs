using apiToDo.DTO;
using apiToDo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas : ITarefaService
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
        public List<TarefaDTO> ListAllTarefas()
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


        public TarefaDTO InserirTarefa(TarefaDTO Request)
        {
            // Verifica se a tarefa já existe
            var tarefaExistente = lstTarefas.FirstOrDefault(t => t.ID_TAREFA == Request.ID_TAREFA);
            if (tarefaExistente != null)
            {
                // Retorna um erro ArgumentNullException caso a tarefa já exista
                throw new ArgumentNullException($"Tarefa com ID {Request.ID_TAREFA} já existe.");
            }

            // verificar a lista de tarefas e atribuir o ID_TAREFA
            // Caso exista algo na lista, atribui o ID_TAREFA como o maior + 1
            // Se a lista estiver vazia, atribui o ID_TAREFA como 1
            int id = lstTarefas.Any() ? lstTarefas.Max(t => t.ID_TAREFA) + 1 : 1;

            // Adiciona o id a nova tarefa
            Request.ID_TAREFA = id;

            // Adiciona a nova tarefa a lista
            lstTarefas.Add(Request);

            // Retorna a tarefa inserida
            return Request;
        }
        public List<TarefaDTO> DeletarTarefa(int ID_TAREFA)
        {
            // Busca a tarefa pelo ID
            var tarefa = lstTarefas.FirstOrDefault(t => t.ID_TAREFA == ID_TAREFA);

            // Verifica se a tarefa existe
            if (tarefa == null)
            {
                // Retorna um erro KeyNotFoundException caso a tarefa não exista
                throw new KeyNotFoundException($"Tarefa com ID {ID_TAREFA} não encontrada.");
            }
            else
            {
                // Remove a tarefa da lista
                lstTarefas.Remove(tarefa);
                return lstTarefas;
            }
        }
    }
}
