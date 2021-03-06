﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Model.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
