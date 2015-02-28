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
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

using Zongsoft.ComponentModel;

namespace Zongsoft.Common
{
	public static class EnumUtility
	{
		/// <summary>
		/// ��ȡָ��ö�����Ӧ��<see cref="Zongsoft.ComponentModel.EnumEntry"/>��������
		/// </summary>
		/// <param name="enumValue">Ҫ��ȡ��ö���</param>
		/// <returns>����ָ��ö��ֵ��Ӧ��<see cref="EnumEntry"/>����</returns>
		public static EnumEntry GetEnumEntry(Enum enumValue)
		{
			return GetEnumEntry(enumValue, false);
		}

		/// <summary>
		/// ��ȡָ��ö�����Ӧ��<see cref="Zongsoft.ComponentModel.EnumEntry"/>��������
		/// </summary>
		/// <param name="enumValue">Ҫ��ȡ��ö���</param>
		/// <param name="underlyingType">�Ƿ����ɵ� <see cref="EnumEntry"/> Ԫ�ص� <see cref="EnumEntry.Value"/> ����ֵ��Ϊ enumType ������Ӧ��ö���������ֵ��</param>
		/// <returns>����ָ��ö��ֵ��Ӧ��<see cref="EnumEntry"/>����</returns>
		public static EnumEntry GetEnumEntry(Enum enumValue, bool underlyingType)
		{
			FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
			var alias = field.GetCustomAttributes(typeof(AliasAttribute), false).OfType<AliasAttribute>().FirstOrDefault();
			var description = field.GetCustomAttributes(typeof(DescriptionAttribute), false).OfType<DescriptionAttribute>().FirstOrDefault();

			return new EnumEntry(field.Name,
								underlyingType ? System.Convert.ChangeType(field.GetValue(null), Enum.GetUnderlyingType(enumValue.GetType())) : field.GetValue(null),
								alias == null ? string.Empty : alias.Alias,
								description == null ? string.Empty : description.Description);
		}

		/// <summary>
		/// ��ȡָ��ö�ٵ������������顣
		/// </summary>
		/// <param name="enumType">Ҫ��ȡ��ö�����͡�</param>
		/// <param name="underlyingType">�Ƿ����ɵ� <see cref="EnumEntry"/> Ԫ�ص� <see cref="EnumEntry.Value"/> ����ֵ��Ϊ enumType ������Ӧ��ö���������ֵ��</param>
		/// <returns>���ص�ö�������������顣</returns>
		public static EnumEntry[] GetEnumEntries(Type enumType, bool underlyingType)
		{
			return GetEnumEntries(enumType, underlyingType, null, string.Empty);
		}

		/// <summary>
		/// ��ȡָ��ö�ٵ������������顣
		/// </summary>
		/// <param name="enumType">Ҫ��ȡ��ö�����ͣ���Ϊ<seealso cref="System.Nullable<>"/>���͡�</param>
		/// <param name="underlyingType">�Ƿ����ɵ� <see cref="EnumEntry"/> Ԫ�ص� <see cref="EnumDescription.Value"/> ����ֵ��Ϊ enumType ������Ӧ��ö���������ֵ��</param>
		/// <param name="nullValue">�������<paramref name="enumType"/>Ϊ�ɿ�����ʱ���ÿ�ֵ��Ӧ��<see cref="EnumDescription.Value"/>���Ե�ֵ��</param>
		/// <returns>���ص�ö�������������顣</returns>
		public static EnumEntry[] GetEnumEntries(Type enumType, bool underlyingType, object nullValue)
		{
			return GetEnumEntries(enumType, underlyingType, nullValue, string.Empty);
		}

		/// <summary>
		/// ��ȡָ��ö�ٵ������������顣
		/// </summary>
		/// <param name="enumType">Ҫ��ȡ��ö�����ͣ���Ϊ<seealso cref="System.Nullable<>"/>���͡�</param>
		/// <param name="underlyingType">�Ƿ����ɵ� <see cref="EnumEntry"/> Ԫ�ص� <see cref="EnumEntry.Value"/> ����ֵ��Ϊ enumType ������Ӧ��ö���������ֵ��</param>
		/// <param name="nullValue">�������<paramref name="enumType"/>Ϊ�ɿ�����ʱ���ÿ�ֵ��Ӧ��<see cref="EnumEntry.Value"/>���Ե�ֵ��</param>
		/// <param name="nullText">�������<paramref name="enumType"/>Ϊ�ɿ�����ʱ���ÿ�ֵ��Ӧ��<see cref="EnumEntry.Description"/>���Ե�ֵ��</param>
		/// <returns>���ص�ö�������������顣</returns>
		public static EnumEntry[] GetEnumEntries(Type enumType, bool underlyingType, object nullValue, string nullText)
		{
			if(enumType == null)
				throw new ArgumentNullException("enumType");

			Type underlyingTypeOfNullable = Nullable.GetUnderlyingType(enumType);
			if(underlyingTypeOfNullable != null)
				enumType = underlyingTypeOfNullable;

			EnumEntry[] entries;
			int baseIndex = (underlyingTypeOfNullable == null) ? 0 : 1;
			var fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);

			if(underlyingTypeOfNullable == null)
				entries = new EnumEntry[fields.Length];
			else
			{
				entries = new EnumEntry[fields.Length + 1];
				entries[0] = new EnumEntry(string.Empty, nullValue, nullText, nullText);
			}

			for(int i = 0; i < fields.Length; i++)
			{
				var alias = fields[i].GetCustomAttributes(typeof(AliasAttribute), false).OfType<AliasAttribute>().FirstOrDefault();
				var description = fields[i].GetCustomAttributes(typeof(DescriptionAttribute), false).OfType<DescriptionAttribute>().FirstOrDefault();

				entries[baseIndex + i] = new EnumEntry(fields[i].Name,
													underlyingType ? System.Convert.ChangeType(fields[i].GetValue(null), Enum.GetUnderlyingType(enumType)) : fields[i].GetValue(null),
													alias == null ? string.Empty : alias.Alias,
													description == null ? string.Empty : Zongsoft.Resources.ResourceUtility.GetString(description.Description, enumType.Assembly));
			}

			return entries;
		}
	}
}
