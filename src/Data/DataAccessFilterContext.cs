﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2010-2017 Zongsoft Corporation <http://www.zongsoft.com>
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

namespace Zongsoft.Data
{
	public class DataAccessFilterContext : DataAccessContextBase
	{
		#region 成员字段
		private DataAccessMethod _method;
		private DataAccessEventArgs _arguments;
		#endregion

		#region 构造函数
		public DataAccessFilterContext(IDataAccess dataAccess, DataAccessMethod method, DataAccessEventArgs arguments) : base(dataAccess)
		{
			if(arguments == null)
				throw new ArgumentNullException(nameof(arguments));

			_method = method;
			_arguments = arguments;
		}
		#endregion

		#region 公共属性
		public override string Name
		{
			get
			{
				return _arguments.Name;
			}
		}

		public override DataAccessMethod Method
		{
			get
			{
				return _method;
			}
		}

		public DataAccessEventArgs Arguments
		{
			get
			{
				return _arguments;
			}
		}
		#endregion
	}
}
