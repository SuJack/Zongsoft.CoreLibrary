﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2008-2013 Zongsoft Corporation <http://www.zongsoft.com>
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
	public class Condition : ICondition
	{
		#region 成员字段
		private string _name;
		private object _value;
		private ConditionOperator _operator;
		#endregion

		#region 构造函数
		public Condition(Condition condition)
		{
			if(condition == null)
				throw new ArgumentNullException("condition");

			_name = condition.Name;
			_value = condition.Value;
			_operator = condition.Operator;
		}

		public Condition(string name, object value, ConditionOperator @operator = ConditionOperator.Equal)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException("name");

			_name = name.Trim();
			_value = value;
			_operator = @operator;
		}
		#endregion

		#region 公共属性
		/// <summary>
		/// 获取或设置子句的标量名称。
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException();

				_name = value.Trim();
			}
		}

		/// <summary>
		/// 获取或设置子句的标量值。
		/// </summary>
		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		/// <summary>
		/// 获取或设置子句的标量操作符。
		/// </summary>
		public ConditionOperator Operator
		{
			get
			{
				return _operator;
			}
			set
			{
				_operator = value;
			}
		}
		#endregion

		#region 公共方法
		public IEnumerable<T> GetValues<T>()
		{
			var values = _value as IEnumerable<T>;

			if(values == null)
				yield return (T)_value;
			else
			{
				foreach(T value in values)
					yield return value;
			}
		}
		#endregion
	}
}
