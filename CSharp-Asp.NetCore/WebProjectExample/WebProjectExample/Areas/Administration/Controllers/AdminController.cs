﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProjectExample.Areas.Administration.Controllers
{
    [Authorize("Admin")]
    [Area("Administration")]
    public class AdminController : Controller
    {
    }
}
