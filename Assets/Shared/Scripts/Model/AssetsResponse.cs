using System;
using System.Collections;
using System.Collections.Generic;

namespace HyperCasual.Runner
{
    [Serializable]
    public class AssetsResponse
    {
        public List<AssetModel> result;
        public PageModel page;
    }

    [Serializable]
    public class AssetResponse
    {
        public AssetModel result;
    }

    [Serializable]
    public class AssetModel
    {
        public string token_id;
        public string image;
        public string name;
        public string contract_address;
        public List<AssetAttribute> attributes;
    }

    [Serializable]
    public class AssetAttribute
    {
        public string trait_type;
        public string value;
    }

}