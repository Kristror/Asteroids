using System.Collections.Generic;

namespace Weapons
{
    public class BulletPool
    {
        private List<BulletMovement> _pool;
        private BulletFactory _bulletFactory;
        private int _poolLength;
        private int _index;

        public BulletPool(BulletFactory bulletFactory)
        {
            _pool = new List<BulletMovement>();
            _bulletFactory = bulletFactory;
        }
        public void FillPool(int poolLenght)
        {
            _poolLength = poolLenght;
            _index = 0;

            for (int i = 0; i < _poolLength; i++)
            {
                BulletMovement bullet = _bulletFactory.Create();
                bullet.SetActive(false);
                _pool.Add(bullet);
            }
        }

        public BulletMovement Next() 
        {
            BulletMovement bullet = _pool[_index];
            AdvanceIndex();
            return bullet;
        }

        private void AdvanceIndex()
        {
            _index++;
            if (_index >= _poolLength) _index = 0;
        }
    }
}