/*
 * Authors:
 *   �ӷ�(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2008-2012 Zongsoft Corporation <http://www.zongsoft.com>
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
using System.ComponentModel;
using System.Collections.Generic;

namespace Zongsoft.Common
{
	/// <summary>
	/// ��ʾö�����������
	/// </summary>
	[Serializable]
	public struct EnumEntry
	{
		#region ��Ա����
		private string _name;
		private object _value;
		private string _alias;
		private string _description;
		#endregion

		#region ���캯��
		public EnumEntry(string name, object value, string alias, string description)
		{
			_name = name;
			_value = value;
			_alias = alias ?? string.Empty;
			_description = description ?? string.Empty;
		}
		#endregion

		#region ��������
		/// <summary>
		/// ��ȡö��������ơ�
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
		}

		/// <summary>
		/// ��ǰ������ö����ֵ����ֵ�п���Ϊö�����ֵҲ�����Ƕ�Ӧ�Ļ�Ԫ����ֵ��
		/// </summary>
		public object Value
		{
			get
			{
				return _value;
			}
		}

		/// <summary>
		/// ��ȡö����ı��������δ���彨�鴴��������Ϊö��������ơ�
		/// </summary>
		/// <remarks>ö����ı�����<seealso cref="Zongsoft.ComponentModel.AliasAttribute"/>�Զ�������ָ����</remarks>
		public string Alias
		{
			get
			{
				return _alias;
			}
		}

		/// <summary>
		/// ��ǰ����ö����������ı������δ���彨�鴴��������Ϊö��������ơ�
		/// </summary>
		/// <remarks>ö�����������<seealso cref="System.ComponentModel.DescriptionAttribute"/>�Զ�������ָ����</remarks>
		public string Description
		{
			get
			{
				return _description;
			}
		}
		#endregion
	}
}