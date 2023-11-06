// libs
import React from 'react';
import classNames from 'classnames/bind';

// components and layouts
import styles from './Menu.module.scss';
import Button from '~/components/Button';

const cx = classNames.bind(styles);

const MenuItems = ({ data }) => {
    return (
        <Button className={cx('menu-item')} leftIcon={data.icon} to={data.to}>
            {data.tilte}
        </Button>
    );
};

export default MenuItems;

// {JSON.stringify(data)} test
