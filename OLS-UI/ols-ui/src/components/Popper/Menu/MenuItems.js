// libs
import React from 'react';
import classNames from 'classnames/bind';

// components and layouts
import styles from './Menu.module.scss';
import Button from '~/components/Button';

const cx = classNames.bind(styles);

const MenuItems = ({ data, onClick }) => {
    const classes = cx('menu-item', {
        separate: data.separate,
    });
    return (
        <Button className={classes} leftIcon={data.icon} to={data.to} onClick={onClick}>
            {data.title}
        </Button>
    );
};

export default MenuItems;

// {JSON.stringify(data)} test
