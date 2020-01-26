#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""
__title__ = ''
__author__ = 'zhangshaohui'
__mtime__ = '1/19/2020'
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

from PIL import Image, ImageFilter

im = Image.open("path40000000.jpg")
#im.show()
print(im.format, im.size, im.mode)


im = im.resize((8, 8), Image.ANTIALIAS).convert('L')
print(list(im.getdata()))
#a = reduce(lambda x, y: x + y, im.getdata())
# print(len(im.getdata()))
# print(a)

#print(list(enumerate(map(lambda i: 0 if i < 200 else 1, im.getdata()))))

# for a in enumerate(map(lambda i: 0 if i < 200 else 1, im.getdata())):
#     print(a)
#
# for a in map(lambda y_z: bin(y_z[1] << y_z[0]), enumerate(map(lambda i: 0 if i < 200 else 1, im.getdata()))):
#     print(a)

# def t(x,y):
#     print(x)
#     print(y)
#     print(x | (y[1] << y[0]))
#     return x | (y[1] << y[0])
#
# reduce(t, [(1,1),(2,1),(3,1)],0)

def avhash(im):
    if not isinstance(im, Image.Image):
        im = Image.open(im)
    im = im.resize((8, 8), Image.ANTIALIAS).convert('L')
    avg = reduce(lambda x, y: x + y, im.getdata()) / 64.
    return reduce(lambda x, y_z: x | (y_z[1] << y_z[0]),
                  enumerate(map(lambda i: 0 if i < avg else 1, im.getdata())),
                  0)
b = avhash(im)
print(bin(b))

#im2 = im.convert("L")
#im2.save("path40000000——BW.jpg")

# 高斯模糊
# im3 = im.filter(ImageFilter.GaussianBlur)
# im3.show()

# 普通模糊
# im3 = im.filter(ImageFilter.BLUR)
# im3.show()

# 边缘增强
# im3 = im.filter(ImageFilter.EDGE_ENHANCE)
# im3.show()

# 找到边缘
# im3 = im.filter(ImageFilter.FIND_EDGES)
# im3.show()

# 浮雕
# im3 = im.filter(ImageFilter.EMBOSS)
# im3.show()

# 轮廓
# im3 = im.filter(ImageFilter.CONTOUR)
# im3.show()

# 锐化
# im3 = im.filter(ImageFilter.SHARPEN)
# im3.show()

# 平滑
# im3 = im.filter(ImageFilter.SMOOTH)
# im3.show()

# 细节
# im3 = im.filter(ImageFilter.DETAIL)
# im3.show()