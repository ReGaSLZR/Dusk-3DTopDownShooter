using NaughtyAttributes;
using ReGaSLZR.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ReGaSLZR.Pooling
{

    public abstract class Pooler<T> : MonoBehaviour where T : MonoBehaviour
    {

        [SerializeField]
        [Required]
        protected T prefabItem;

        [SerializeField]
        protected uint poolLength = 15;

        protected Transform itemsParent;
        protected List<T> items = new List<T>();
        protected int currentIndex = 0;

        #region Unity Callbacks

        protected virtual void Awake()
        {
            if (prefabItem == null)
            {
                LogUtil.PrintError(GetType(), "Cannot work when prefabItem is NULL.");
                Destroy(this);
            }

            itemsParent = new GameObject("Pool of " + prefabItem.GetType().Name).transform;

            for (int x=0; x<poolLength; x++)
            {
                var item  = Instantiate(prefabItem, itemsParent);
                item.gameObject.SetActive(false);
                items.Add(item);
            }
        }

        protected virtual void OnDisable()
        {
            foreach (var item in items)
            {
                if (item == null)
                {
                    continue;
                }

                item.gameObject.SetActive(false);
            }
        }

        #endregion

        #region Public API

        public T GetPooledItem()
        {
            currentIndex = (currentIndex >= (poolLength-1)) ? 0 : (currentIndex + 1);
            var item = items[currentIndex];
            item.gameObject.SetActive(true);
            return item;
        }

        public void ReturnPooledItem(T item)
        {
            if (item == null)
            {
                return;
            }

            for (int x=0; x<items.Count; x++)
            {
                if (items[x] == null)
                {
                    continue;
                }

                if (items[x].GetHashCode() == item.GetHashCode())
                {
                    item.gameObject.SetActive(false);
                    item.transform.SetParent(itemsParent);
                }
            }
        }

        #endregion

    }

}