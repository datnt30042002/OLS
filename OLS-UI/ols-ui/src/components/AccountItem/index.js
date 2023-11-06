// libs
import React from 'react';
import classNames from 'classnames/bind';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCheckCircle } from '@fortawesome/free-solid-svg-icons';

// components
import styles from './AccountItem.module.scss';
import Image from '~/components/Image';

// account item là những Account items được xuất hiện trong list gợi ý của Popper
/*
- avatar 
- name
- tich xanh
*/

const cx = classNames.bind(styles);

const AccountItem = () => {
    return (
        <div className={cx('wrapper')}>
            <Image
                className={cx('avatar')}
                src="https://avatars.githubusercontent.com/u/108357953?v=4"
                alt="Bui Van Kien"
            />
            <div className={cx('info')}>
                <h4 className={cx('name')}>
                    <span>Bui Van Kien</span>

                    {/* icon tich xanh */}
                    <FontAwesomeIcon className={cx('check')} icon={faCheckCircle} />
                </h4>
                <span className={cx('username')}>buivankien</span>
            </div>
        </div>
    );
};

export default AccountItem;
