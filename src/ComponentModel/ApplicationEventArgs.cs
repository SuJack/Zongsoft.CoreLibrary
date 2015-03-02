﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2003-2013 Zongsoft Corporation <http://www.zongsoft.com>
 *
 * This file is part of Zongsoft.CoreLibrary.
 *
 * Zongsoft.CoreLibrary is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * Zongsoft.CoreLibrary is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with Zongsoft.CoreLibrary; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Zongsoft.ComponentModel
{
	public class ApplicationEventArgs : EventArgs
	{
		#region 成员变量
		private string[] _args;
		private ApplicationContextBase _applicationContext;
		#endregion

		#region 构造函数
		public ApplicationEventArgs(ApplicationContextBase applicationContext, string[] args)
		{
			_applicationContext = applicationContext;
			_args = args ?? new string[0];
		}
		#endregion

		#region 公共属性
		public ApplicationContextBase ApplicationContext
		{
			get
			{
				return _applicationContext;
			}
		}

		public string[] Arguments
		{
			get
			{
				return _args;
			}
		}
		#endregion
	}
}
