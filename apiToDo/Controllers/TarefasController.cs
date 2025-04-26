using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {

        private readonly Tarefas _model = new Tarefas();

        [HttpGet]
        public ActionResult<List<TarefaDTO>> GetAllTarefas()
        {
            try
            {
                // Chama o método para listar todas as tarefas
                var lstTarefas = _model.listAllTarefas();

                // Verifica se a lista está vazia se sim retorna um NoContent Vazio
                if (lstTarefas.Count == 0)
                    return StatusCode(204, new { msg = "Nenhum registro encontrado" });

                // Retorna a lista de tarefas
                return Ok(lstTarefas);
            }

            catch (Exception ex)
            {
                // Retorna um erro 400 com a mensagem de erro, uma simulação em caso de uma api da erro
                return BadRequest(new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TarefaDTO> GetTarefa(int id)
        {
            try
            {
                // Chama o método para retornar uma tarefa pelo ID
                var tarefa = _model.GetTarefa(id);

                // Retorna a tarefa encontrada
                return Ok(tarefa);
            }

            catch (KeyNotFoundException ex)
            {
                // Retorna um erro 404 caso a tarefa não seja encontrada
                return NotFound(new { msg = ex.Message });
            }
            catch (Exception ex)
            {
                // Retorna um erro 400 com a mensagem de erro, uma simulação em caso de uma api da erro
                return BadRequest(new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [Authorize]
        [HttpPost("InserirTarefas")]
        public ActionResult<TarefaDTO> CreateNewTarefa([FromBody] TarefaDTO Request)
        {
            try
            {
                // Chama o método para inserir uma nova tarefa
                var tarefa = _model.InserirTarefa(Request);

                // Retorna a tarefa inserida
                return Ok(tarefa);
            }

            catch (ArgumentNullException ex)
            {
                // Retorna um erro 400 caso a tarefa já exista
                return BadRequest(new { msg = ex.Message });
            }
            catch (Exception ex)
            {
                // Retorna um erro 400 com a mensagem de erro, uma simulação em caso de uma api da erro
                return BadRequest(new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }


        [HttpGet("DeletarTarefa/{id}")]
        public ActionResult DeleteTask( int id)
        {
            try
            {

                // Chama o método para deletar uma tarefa
                var tarefa = _model.DeletarTarefa(id);

                // Retorna a lista de tarefas restantes
                return Ok(tarefa);
            }

            catch (KeyNotFoundException ex)
            {
                // Retorna um erro 404 caso a tarefa não seja encontrada
                return NotFound(new { msg = ex.Message });
            }

            catch (Exception ex)
            {
                // Retorna um erro 400 com a mensagem de erro, uma simulação em caso de uma api da erro
                return BadRequest(new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
