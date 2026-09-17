using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviourPatterns_TemplateMethod
{
    internal abstract class RequestHandler<TREquest>
    {
        private string _log = "";
        //шаблонный метод
        public ApiResponse Handler(TREquest request, string userID)
        {
            Log($"входящий запрос от пользователя {userID}");
            if (Validate(request, userID))
            {
                var responce = Execute(request, userID);
                Log($"запрос от пользователя {userID} успешно выполнен");
                return new ApiResponse(200, userID);
            }
            else
            {
                Log($"запрос от пользователя {userID} отклонен");
                return new ApiResponse(400, userID);

            }
        }

        public string GetLog => _log;
        void Log(string message) => _log += message;
        protected abstract bool Validate(TREquest request, string userID);
        protected abstract string Execute(TREquest request, string userID);

    }
}
