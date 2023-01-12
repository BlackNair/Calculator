using Calc.Interfaces;
using Calc.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Calc.Controllers
{
    [ApiController]
    [Route("api")]
    public class CalcController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static readonly IValue valueWorker = new ValueWork();

        [Route("multiplication")]
        [HttpPost]
        public IActionResult Multiplication(ValueModel valueModel)
        {
            try
            {
                Logger.Info("Operation: multiplication - start");
                return Ok(valueWorker.Mult(valueModel.ValueA, valueModel.ValueB));
            }
            catch (Exception ex)
            {
                Logger.Info("Operation: multiplication - error");
                Logger.Info(ex.Message);
                return BadRequest(ex.Message);
            }
            finally
            {
                Logger.Info("Operation: multiplication - end");
            }
        }

        [Route("sum")]
        [HttpPost]
        public IActionResult Sum(ValueModel valueModel)
        {
            try
            {
                Logger.Info("Operation: sum - start");
                return Ok(valueWorker.Sum(valueModel.ValueA, valueModel.ValueB));
            }
            catch (Exception ex)
            {
                Logger.Info("Operation: sum - error");
                Logger.Info(ex.Message);
                return BadRequest(ex.Message);
            }
            finally
            {
                Logger.Info("Operation: sum - end");
            }
        }

        [Route("division")]
        [HttpPost]
        public IActionResult Division(ValueModel valueModel)
        {
            try
            {
                Logger.Info("Operation: division - start");
                return Ok(valueWorker.Div(valueModel.ValueA, valueModel.ValueB));
            }
            catch (Exception ex)
            {
                Logger.Info("Operation: division - error");
                Logger.Info(ex.Message);
                return BadRequest(ex.Message);
            }
            finally
            {
                Logger.Info("Operation: division - end");
            }
        }

        [Route("subtraction")]
        [HttpPost]
        public IActionResult Subtraction(ValueModel valueModel)
        {
            try
            {
                Logger.Info("Operation: subtraction - start");
                return Ok(valueWorker.Sub(valueModel.ValueA, valueModel.ValueB));
            }
            catch (Exception ex)
            {
                Logger.Info("Operation: subtraction - error");
                Logger.Info(ex.Message);
                return BadRequest(ex.Message);
            }
            finally
            {
                Logger.Info("Operation: subtraction - end");
            }
        }
    }
}
