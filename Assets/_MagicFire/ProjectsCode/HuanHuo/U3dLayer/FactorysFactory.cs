/* --------------------------
 * Company: MagicFire Studio
 *   Autor: Changmin Yang
 *   ������: ���������Ĺ���
 * -------------------------- */
using MagicFire.Mmorpg;
using MagicFire.Mmorpg.UI;

namespace MagicFire
{
    using System;
    using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    /// <summary>
    /// ���������Ĺ���
    /// </summary>
    public class FactorysFactory : BaseSingleton<FactorysFactory>
    {
        private readonly Dictionary<Type, IBaseFactory> _factorys = new Dictionary<Type, IBaseFactory>();

        private FactorysFactory()
        {
        }

        public IBaseFactory CreateFactory<TFactoryType>(params object[] factoryParameters) where TFactoryType: IBaseFactory
        {
            return CreateProduct<TFactoryType>(factoryParameters);
        }

        public TFactoryType CreateProduct<TFactoryType>(params object[] productParameters)
        {
            return (TFactoryType)CreateProduct(typeof(TFactoryType), productParameters);
        }

        public object CreateProduct(Type productType, params object[] productParameters)
        {
            IBaseFactory factory;
            _factorys.TryGetValue(productType, out factory);
            if (factory == null)
            {
                factory = Activator.CreateInstance(productType) as IBaseFactory;
                _factorys.Add(productType, factory);
            }
            return factory;
        }
    }
}
