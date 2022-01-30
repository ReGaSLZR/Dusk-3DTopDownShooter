using NaughtyAttributes;
using ReGaSLZR.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace ReGaSLZR.Pooling
{

    public abstract class Pooler<T> : MonoBehaviour where T : MonoBehaviour
    {

        #region Inspector Fields

        [SerializeField]
        [Required]
        protected T prefabItem;

        [SerializeField]
        private bool selfSetup;

        [SerializeField]
        [EnableIf("selfSetup")]
        private uint poolLength = 10;

        #endregion

        protected Transform itemsParent;
        protected List<T> items = new List<T>();
        protected int currentIndex = 0;

        #region Unity Callbacks

        protected virtual void Awake()
        {
            if (selfSetup)
            {
                SetUp(poolLength);
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

        public void SetUp(uint poolLength)
        {
            if (prefabItem == null)
            {
                LogUtil.PrintError(GetType(), "Cannot work when prefabItem is NULL.");
                Destroy(this);
            }

            if (itemsParent != null)
            {
                DestroyImmediate(itemsParent.gameObject);
            }

            itemsParent = new GameObject("Pool of " + prefabItem.GetType().Name).transform;
            items.Clear();

            for (int x = 0; x < poolLength; x++)
            {
                var item = Instantiate(prefabItem, itemsParent);
                item.gameObject.SetActive(false);
                items.Add(item);
            }
        }

        public T GetPooledItem()
        {
            currentIndex = (currentIndex >= (items.Count-1)) ? 0 : (currentIndex + 1);
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