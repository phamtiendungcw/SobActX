using System.Linq.Expressions;

using SAX.Domain.Entities;

namespace SAX.Application.Common.Contracts.Persistence;

public interface ISpecification<T> where T : BaseEntity
{
    /// <summary>
    ///     Lấy biểu thức tiêu chí dùng để lọc các entity.
    /// </summary>
    Expression<Func<T, bool>> Criteria { get; }

    /// <summary>
    ///     Lấy danh sách các biểu thức cho việc eager loading các entity liên quan (Include).
    /// </summary>
    List<Expression<Func<T, object>>> Includes { get; }

    /// <summary>
    ///     Lấy danh sách các chuỗi include cho việc eager loading các entity liên quan (Include).
    /// </summary>
    List<string> IncludeStrings { get; }

    /// <summary>
    ///     Lấy biểu thức để sắp xếp các entity theo thứ tự tăng dần.
    /// </summary>
    Expression<Func<T, object>>? OrderBy { get; }

    /// <summary>
    ///     Lấy biểu thức để sắp xếp các entity theo thứ tự giảm dần.
    /// </summary>
    Expression<Func<T, object>>? OrderByDescending { get; }

    /// <summary>
    ///     Lấy số lượng entity cần lấy (cho phân trang).
    /// </summary>
    int Take { get; }

    /// <summary>
    ///     Lấy số lượng entity cần bỏ qua (cho phân trang).
    /// </summary>
    int Skip { get; }

    /// <summary>
    ///     Lấy giá trị cho biết phân trang có được bật hay không.
    /// </summary>
    bool IsPagingEnabled { get; }

    /// <summary>
    ///     Thêm một biểu thức Include cho việc eager loading.
    /// </summary>
    /// <param name="includeExpression">Biểu thức include.</param>
    void AddInclude(Expression<Func<T, object>> includeExpression);

    /// <summary>
    ///     Thêm một chuỗi Include cho việc eager loading.
    /// </summary>
    /// <param name="includeString">Chuỗi include.</param>
    void AddInclude(string includeString);

    /// <summary>
    ///     Áp dụng sắp xếp tăng dần cho specification.
    /// </summary>
    /// <param name="orderByExpression">Biểu thức sắp xếp.</param>
    void ApplyOrderBy(Expression<Func<T, object>> orderByExpression);

    /// <summary>
    ///     Áp dụng sắp xếp giảm dần cho specification.
    /// </summary>
    /// <param name="orderByDescendingExpression">Biểu thức sắp xếp giảm dần.</param>
    void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression);

    /// <summary>
    ///     Áp dụng phân trang cho specification.
    /// </summary>
    /// <param name="skip">Số lượng entity cần bỏ qua.</param>
    /// <param name="take">Số lượng entity cần lấy.</param>
    void ApplyPaging(int skip, int take);

    /// <summary>
    ///     Bật phân trang cho specification.
    /// </summary>
    void EnablePaging();
}