﻿namespace SharpVk.Generator.Collation
{
    public class MemberDeclaration
        : ITypedDeclaration
    {
        public string VkName;
        public string Name;
        public string ParamName;
        public TypeReference Type;
        public string FixedValue;
        public MemberLen[] Dimensions;

        public bool RequiresMarshalling => this.Type.PointerType.IsPointer() || this.Type.FixedLength.Type != FixedLengthType.None;

        string ITypedDeclaration.Name => this.Name;

        TypeReference ITypedDeclaration.Type => this.Type;

        string ITypedDeclaration.VkName => this.VkName;

        string ITypedDeclaration.FixedValue => this.FixedValue;

        MemberLen[] ITypedDeclaration.Dimensions => this.Dimensions;
    }
}