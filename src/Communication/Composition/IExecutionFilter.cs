﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2010-2013 Zongsoft Corporation <http://www.zongsoft.com>
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

namespace Zongsoft.Communication.Composition
{
	/// <summary>
	/// 提供过滤执行管道的功能。
	/// </summary>
	public interface IExecutionFilter
	{
		/// <summary>
		/// 获取执行过滤器的名称。
		/// </summary>
		string Name
		{
			get;
		}

		/// <summary>
		/// 表示在执行处理程序之前被激发调用。
		/// </summary>
		/// <param name="context">当前执行上下文对象。</param>
		void OnExecuting(IExecutionContext context);

		/// <summary>
		/// 表示在执行处理程序之后被激发调用。
		/// </summary>
		/// <param name="context">当前执行上下文对象。</param>
		void OnExecuted(IExecutionContext context);
	}
}