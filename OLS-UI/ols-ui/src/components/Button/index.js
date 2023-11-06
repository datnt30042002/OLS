// libs
import React from 'react';
import classNames from 'classnames/bind';
import { Link } from 'react-router-dom';

// layouts
import styles from './Button.module.scss';

/*
- Button có thể tái sử dụng dựa vào tư duy
*/

const cx = classNames.bind(styles); // bind object styles tra ve 1 function cx

// props
// to: link noi bo,
// href: link ben ngoai,
// onClick: tinh huong tuong tac voi nut, onclick lang nghe nut
const Button = ({
    to,
    href,
    primary = false,
    outline = false,
    text = false,
    rounded = false,
    disable = false,
    small = false,
    large = false,
    children,
    className,
    leftIcon,
    rightIcon,
    onClick,
    ...passProps
}) => {
    // component
    let Component = 'button';
    // bắt sự kiện onClick
    const props = {
        onClick,
        ...passProps,
    };

    // check disable -> bỏ onClick để thực hiện login k thể clcik
    // xóa những event listener when btn is disabled
    // hầu hết những events trong dom đều bắt đầu bằng 'on' -> làm logic lặp 1 phát ăn ngay
    if (disable) {
        //delete props.onClick;
        Object.keys(props).forEach((key) => {
            //console.log(key);
            if (key.startsWith('on') && typeof props[key] === 'function') {
                delete props[key];
            }
        });
    }

    // check
    if (to) {
        // nội bộ trang web
        props.to = to;
        Component = Link; // bằng Link
    } else if (href) {
        // bên ngoài
        props.href = href;
        Component = 'a'; // bằng thẻ a
    }

    const classes = cx('wrapper', {
        // style cho button
        // className cho việc custom diêng:)
        [className]: className,
        primary,
        outline,
        text,
        rounded,
        disable,
        small,
        large,
    });

    return (
        <Component className={classes} {...props}>
            {leftIcon && <span className={cx('icon')}>{leftIcon}</span>}
            <span className={cx('title')}>{children}</span>
            {rightIcon && <span className={cx('icon')}>{rightIcon}</span>}
        </Component>
    );
};

export default Button;
