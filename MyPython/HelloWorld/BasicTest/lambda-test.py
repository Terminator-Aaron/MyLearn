#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""
__title__ = ''
__author__ = 'zhangshaohui'
__mtime__ = '1/20/2020'
# code is far away from bugs with the god animal protecting
    I love animals. They taste delicious.
              ┏┓      ┏┓
            ┏┛┻━━━┛┻┓
            ┃      ☃      ┃
            ┃  ┳┛  ┗┳  ┃
            ┃      ┻      ┃
            ┗━┓      ┏━┛
                ┃      ┗━━━┓
                ┃  神兽保佑    ┣┓
                ┃　永无BUG！   ┏┛
                ┗┓┓┏━┳┓┏┛
                  ┃┫┫  ┃┫┫
                  ┗┻┛  ┗┻┛
"""
from functools import reduce

# foo = [2, 18, 9, 22, 17, 24, 8, 12, 27]
# print(list(filter(lambda x:x % 3 == 0, foo)))
# print(reduce(lambda x, y: x + y, foo))
# print(list(map(lambda x: x * 2 + 10, foo)))

# seasons = ['Spring', 'Summer', 'Fall', 'Winter']
# print(list(enumerate(seasons)))

# def t(x,y):
#     print(x)
#     print(y)
#     print(x | (y[1] << y[0]))
#     return x | (y[1] << y[0])
#
# reduce(t, [(1,1),(2,1),(3,1)],0)

# a = 60
# b = 13
# print(bin(a))
# print(bin(b))
#
# print(bin(a & b))
# print(bin(a | b))
# print(bin(a >> 2))
# print(bin(a << 2))
# print(bin(a ^ b), (a ^ b))

def hamming(d):
    while d:
        print(d)
        print(bin(d))
        print(bin(d - 1))
        d &= d - 1

hamming(49)