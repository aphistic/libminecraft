using System;
using System.Collections.Generic;
using System.Text;
using LibNbt.Tags;

namespace LibMinecraft.Entity
{
    public class McEntity
    {
        private NbtCompound _test;
        internal void LoadEntity(NbtCompound entity)
        {
            _test = entity;
        }

        internal NbtCompound SaveEntity()
        {
            return _test;
        }

        public virtual McEntityType GetEntityType() { return McEntityType.Unknown; }
    }
}
