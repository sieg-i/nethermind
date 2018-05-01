/*
 * Copyright (c) 2018 Demerzel Solutions Limited
 * This file is part of the Nethermind library.
 *
 * The Nethermind library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The Nethermind library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using Nethermind.Core.Extensions;

namespace Nethermind.Store
{
    public class MemDb : IDb
    {
        private readonly Dictionary<byte[], byte[]> _db;
        
        public byte[] this[byte[] key]
        {
            get => _db.ContainsKey(key) ? _db[key] : null;
            set => _db[key] = value;
        }

        public bool ContainsKey(byte[] key)
        {
            return _db.ContainsKey(key);
        }

        public void Remove(byte[] key)
        {
            _db.Remove(key);
        }

        public MemDb()
        {
            _db = new Dictionary<byte[], byte[]>(1024, Bytes.EqualityComparer);
        }
    }
}